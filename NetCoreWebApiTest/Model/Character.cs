using System.Formats.Asn1;

namespace NetCoreWebApiTest.Model
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Devian";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        //public RpgClass Class { get; set; } = RpgClass.Knight;
        public User? User { get; set; }
    }
}
