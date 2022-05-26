using AppSeries.src.Enums;

namespace AppSeries.src.Classes
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Deleted { get; set; }

        public Series(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string returnStr = "";
            returnStr += "Genre: " + this.Genre + Environment.NewLine;
            returnStr += "Title: " + this.Title + Environment.NewLine;
            returnStr += "Description: " + this.Description + Environment.NewLine;
            returnStr += "Year: " + this.Year;
            returnStr += "Deleted " + this.Deleted;
            return returnStr;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnDeleted()
        {
            return this.Deleted;
        }

        public void DeleteTrue()
        {
            this.Deleted = true;
        }
    }
}