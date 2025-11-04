namespace LogisticsCorp.Data.Models
{
    public class CompanyInfo
    {
        public Guid Id { get; set; }

        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Adress { get; set; } = default!;
        public string MondaySchedule { get; set; } = default!;
        public string TuesdaySchedule { get; set; } = default!;
        public string WednesdaySchedule { get; set; } = default!;
        public string ThursdaySchedule { get; set; } = default!;
        public string FridaySchedule { get; set; } = default!;
        public string SaturdaySchedule { get; set; } = default!;
        public string SundaySchedule { get; set; } = default!;
    }
}
