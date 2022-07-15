namespace CompMarketReal.Models.Data.Tovars.ComputerItems
{
    public class Components
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int EnergoPotrebl { get; set; }
        public string? Seria { get; set; }
        public DateTime DateCreate { get; set; }
        public string? Type { get; set; }
        public string? SpeedChtenia { get; set; }
        public string? SpeedWrite { get; set; }
        //Если процессор и материнка
        public string? Socket { get; set; }
        //Если Материнка
        public string? Slots { get; set; }
        //Если куллер 
        public string? TypeCollers { get; set; }
        //Если Озу
        public string? DDRType { get; set; }
        //Если Блок питания
        public int Volts{ get; set; }
        public string? Description { get; set; }
        public virtual componetnType? ComponetnType { get; set; }

    }
}
