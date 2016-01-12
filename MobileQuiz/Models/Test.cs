namespace MobileQuiz.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public int RightAnswers { get; set; }
        public int TotalAnswers { get; set; }
    }
}