namespace AdvancedForm.Models
{
    public class ContentItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }   
        public string? Address { get; set; }       
        public int Sequence { get; set; }
        public string? ImagePath { get; set; }     
    }

}
