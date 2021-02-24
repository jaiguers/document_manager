namespace DocumentManager.CrossCutting.ApplicationModel
{
    public class DepartmentAM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long IdState { get; set; }
        public StatesAM States { get; set; }
    }
}
