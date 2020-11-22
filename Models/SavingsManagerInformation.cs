using System.ComponentModel.DataAnnotations;


namespace SmartSaver.Models
{
    public partial class SavingsManagerInformation
    {

        public int ID { get; set; }
        public string Purpose { get; set; }

    
       
        public int Cost { get; set; }

        
     
        public string Date { get; set; }

        public int SavedAmount { get; set; }

       
        
        public string Status { get; set; }

        public int user_id { get; set; }
    }
}
