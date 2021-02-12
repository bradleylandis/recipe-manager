namespace recipemanager.business
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Recipe Recipe { get; set; }
    }
}