namespace Fiver.Asp.Docker.Api.Models.Movies
{
    public class MovieUpdateInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
    }
}
