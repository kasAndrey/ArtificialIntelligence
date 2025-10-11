using MathObjects;

namespace ArtificialIntelligence.FuzzyLogic
{
    public class RobotDummy
    {
        public double FOV;
        public double Size;
        public double Angle;
        public Vector Position;

        public RobotDummy(Vector pos, double size = 0.33)
        {
            Angle = 0;
            FOV = 90;
            Position = pos;
            Size = size > 0.99 ? 0.99 : size < 0.1 ? 0.1 : size;
        }
    }

    public class FuzzyRelation : Dictionary<string, PointF[]>
    {
        public FuzzyRelation() : base() { }

        public Dictionary<string, double> GetRelationsForValue(double value)
        {
            if (value > 1 || value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Value should be between 0 and 1");

            Dictionary<string, double> values = new();

            foreach (var pair in this)
            {
                for (int i = 1; i < pair.Value.Length; i++)
                {
                    if (value <= pair.Value[i].X)
                    {
                        PointF first = pair.Value[i - 1], second = pair.Value[i];
                        values.Add(pair.Key, (value - first.X) / (second.X - first.X) * (second.Y - first.Y) + first.Y);
                        break;
                    }
                }

                if (!values.ContainsKey(pair.Key)) values.Add(pair.Key, 0);
            }

            return values;
        }

        public double Defuzzificate(Dictionary<string, double> relations)
        {
            Dictionary<string, List<PointF>> cutted = new();

            // Cutting
            foreach (string key in relations.Keys)
            {
                PointF[] curPoints = this[key];
                List<PointF> cuttedPoints = new();
                for (int i = 0; i < curPoints.Length; i++)
                {
                    if (curPoints[i].Y > relations[key])
                        cuttedPoints.Add(new PointF(curPoints[i].X, (float)relations[key]));
                    else
                        cuttedPoints.Add(curPoints[i]);

                    if (i < curPoints.Length - 1 && curPoints[i + 1].Y - curPoints[i].Y != 0)
                    {
                        double t = (relations[key] - curPoints[i].Y) / (curPoints[i + 1].Y - curPoints[i].Y);
                        if (t > 0 && t < 1)
                        {
                            double x = (curPoints[i + 1].X - curPoints[i].X) * t + curPoints[i].X;
                            cuttedPoints.Add(new PointF((float)x, (float)relations[key]));
                        }
                    }
                }

                cutted.Add(key, cuttedPoints);
            }

            List<PointF> result = new();
            // Crossing, finding intersections
            for (int i = 0; i < cutted.Keys.Count - 1; i++)
            {
                List<PointF> currentRel = cutted[cutted.Keys.ElementAt(i)];
                List<PointF> comparedTo = cutted[cutted.Keys.ElementAt(i + 1)];
                for (int k = 0; k < comparedTo.Count; k++)
                {
                    if (currentRel[k].X - comparedTo[k].X > 0)
                    {
                        double y = currentRel[k - 1].Y + (currentRel[k].Y - currentRel[k - 1].Y) * (comparedTo[k].X - comparedTo[k - 1].X) / (currentRel[k].X - currentRel[k - 1].X);
                        currentRel.Insert(k, new((float)comparedTo[k].X, (float)y));
                    }
                    else if (currentRel[k].X - comparedTo[k].X < 0)
                    {
                        double y = comparedTo[k - 1].Y + (comparedTo[k].Y - comparedTo[k - 1].Y) * (currentRel[k].X - currentRel[k - 1].X) / (comparedTo[k].X - comparedTo[k - 1].X);
                        comparedTo.Insert(k, new((float)currentRel[k].X, (float)y));
                    }

                    if (k != 0)
                    {
                        double A1 = currentRel[k].Y - currentRel[k - 1].Y, A2 = comparedTo[k].Y - comparedTo[k - 1].Y;
                        double B1 = currentRel[k - 1].X - currentRel[k].X, B2 = comparedTo[k - 1].X - comparedTo[k].X;
                        double C1 = -currentRel[k - 1].X * A1 - currentRel[k - 1].Y * B1, C2 = -comparedTo[k - 1].X * A2 - comparedTo[k - 1].Y * B2;

                        double D11 = A1 * comparedTo[k - 1].X + B1 * comparedTo[k - 1].Y + C1;
                        double D12 = A1 * comparedTo[k].X + B1 * comparedTo[k].Y + C1;
                        double D21 = A2 * currentRel[k - 1].X + B2 * currentRel[k - 1].Y + C2;
                        double D22 = A2 * currentRel[k].X + B2 * currentRel[k].Y + C2;

                        if (D11 != D12 && D21 != D22)
                        {
                            double k1 = D11 / (D11 - D12), k2 = D21 / (D21 - D22);
                            if (k1 < 1 && k1 > 0 && k2 < 1 && k2 > 0)
                            {
                                double newX = currentRel[k - 1].X + k2 * (currentRel[k].X - currentRel[k - 1].X);
                                double newY = currentRel[k - 1].Y + k2 * (currentRel[k].Y - currentRel[k - 1].Y);

                                result.Add(new((float)newX, (float)newY));
                            }
                        }
                    }

                    result.Add(currentRel[k].Y > comparedTo[k].Y ? currentRel[k] : comparedTo[k]);
                }
            }

            // Calculating center of mass
            double numerator = 0, denominator = 0;
            foreach (PointF p in result)
            {
                numerator += p.X * p.Y;
                denominator += p.Y;
            }
            return numerator / denominator;
        }
    }

    public class FuzzyLogicRobotController
    {
        private RobotDummy robot;

        private double angularVelocity;
        private double velocity;

        private ObstacleMap obstacleMap;

        private Dictionary<string, double>? dangerF, dangerR, dangerL, vel, angVel;

        private readonly FuzzyRelation dangerRelation = new() {
                { "Low", new PointF[4] { new(0, 1), new(0.25f, 1), new(0.55f, 0), new(1, 0) } },
                { "High", new PointF[4] { new(0, 0), new(0.45f, 0), new(0.75f, 1), new(1, 1) } }
            };

        private readonly FuzzyRelation velocityRelation = new() {
                { "Low", new PointF[5] { new(-0.025f, 1), new(0.02f, 1), new(0.05f, 0.6f), new(0.13f, 0), new(0.2f, 0) } },
                { "High", new PointF[5] { new(-0.025f, 0), new(0.05f, 0), new(0.13f, 0.6f), new(0.16f, 1), new(0.2f, 1) } }
            };

        private readonly FuzzyRelation angVelocityRelation = new() {
                { "Right", new PointF[4] { new(-12f, 1), new(-6f, 0.3f), new(0, 0), new(12f, 0) } },
                { "Left", new PointF[4] { new(-12f, 0), new(0, 0), new(6f, 0.3f), new(12f, 1) } }
            };

        public Vector RobotPosition { get { return robot.Position; } }

        public FuzzyLogicRobotController(Vector initPosition, double robotSize, in ObstacleMap map)
        {
            robot = new(initPosition, robotSize);
            obstacleMap = map;
        }

        public void MakeOneIteration()
        {
            double d = GetDangerValue(robot.Angle);
            double f = robot.FOV / 2 * (1 - d * 0.97);
            dangerF = dangerRelation.GetRelationsForValue(d);
            dangerR = dangerRelation.GetRelationsForValue(GetDangerValue(robot.Angle - f));
            dangerL = dangerRelation.GetRelationsForValue(GetDangerValue(robot.Angle + f));

            ApplyRules();

            robot.Angle += angularVelocity;
            robot.Position += new Vector(Math.Sin(MathDefs.DegToRad(robot.Angle)), Math.Cos(MathDefs.DegToRad(robot.Angle))) * velocity;
        }

        private double GetDangerValue(double angle)
        {
            double distance = robot.Size, delta = 1e-3;
            Vector direction = new(Math.Sin(MathDefs.DegToRad(angle)), Math.Cos(MathDefs.DegToRad(angle)));

            Vector currentPoint = robot.Position + direction * distance;
            while (!obstacleMap.ObstacleAtPoint(currentPoint))
            {
                distance += delta;
                currentPoint = robot.Position + direction * distance;
            }

            return distance <= 2 * robot.Size ? 1 : 2 * robot.Size / distance;
        }

        private void ApplyRules()
        {
            if (dangerF is null || dangerL is null || dangerR is null)
                throw new ArgumentNullException(nameof(dangerF), "Fuzzification is not complete");

            static double OrFunction(params double[] values) => values.Max();
            static double AndFunction(params double[] values) => values.Min();

            vel = new();
            angVel = new();

            vel.Add("High", OrFunction(dangerF["Low"], dangerL["Low"], dangerR["Low"]));
            vel.Add("Low", OrFunction(dangerF["High"], dangerL["High"], dangerR["High"]));

            if (AndFunction(dangerR["High"], dangerL["High"], dangerF["High"]) > 0.95)
            {
                angVel.Add("Right", 1);
                angVel.Add("Left", 0);
            }
            else
            {
                angVel.Add("Left",OrFunction(dangerR["High"], dangerL["Low"]));
                angVel.Add("Right", OrFunction(dangerR["Low"], dangerL["High"]));
            }

            velocity = velocityRelation.Defuzzificate(vel);
            angularVelocity = angVelocityRelation.Defuzzificate(angVel);
        }
    }
}
