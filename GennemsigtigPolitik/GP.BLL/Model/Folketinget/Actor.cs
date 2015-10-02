using System;

namespace GP.BLL.Model.Folketinget
{
    public class Actor
    {
        public int Id { get; set; }

        public string Biography { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GroupnameCard { get; set; }

        public string Name { get; set; }

        public DateTime LastUpdated { get; set; }

        public int? PeriodId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TypeId { get; set; }
    }
}