namespace Lab1.Models
{
    public class AircraftTreeCell
    {
        public Aircraft Value { get; set; }

        public Aircraft Left { get; set; }
        public Aircraft Right { get; set; }

        public static explicit operator Aircraft(AircraftTreeCell aircraftTreeCell)
            => aircraftTreeCell.Value;

        public override string ToString()
            => ((Aircraft) this).ToString();
    }
}