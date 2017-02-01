using SharpDX;

namespace BlackYasuo
{
    internal class DashPosition
    {
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public DashPosition()
        {
            From = new Vector3(-1, -1, -1);
            To = new Vector3(-1, -1, -1);
        }

        public DashPosition(Vector3 fromV, Vector3 toV)
        {
            From = fromV;
            To = toV;
        }

        public DashPosition(DashPosition dash)
        {
            From = dash.From;
            To = dash.To;
        }

    }
}