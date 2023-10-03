using NetCoreWebApiTest.Model;

namespace NetCoreWebApiTest.DOTs
{
    public class GetCharacterResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}
