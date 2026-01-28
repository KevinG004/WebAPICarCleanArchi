namespace CarApiClean.DTOs.Responses
{
    public class CarAddResponseDTO
    {
        public string Models { get; set; } = null!;

        public int Tire { get; set; }

        public int HorsePower { get; set; }
    }
    public class PatchDTO
    {
        public string Models { get; set; } = null!;
    }
}
