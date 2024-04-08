using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbModels
{
    public class CommentDbModel
    {
        public static List<int> commentIds = new List<int>();
        public CommentDbModel(int userId, int reportId, DateTime postedOn, string commentContent, UserDbModel user)
        {
            UserId = userId;
            ReportId = reportId;
            PostedOn = postedOn;
            CommentContent = commentContent;
            User = user;

            StringBuilder stringId = new StringBuilder(8);
            int id;
            Random rand = new Random();
            do
            {
                stringId.Clear();
                for (int i = 0; i < 8; i++)
                {
                    stringId.Append(rand.Next(0, 10));
                }
                id = int.Parse(stringId.ToString());
            }
            while (commentIds.Contains(id));

            commentIds.Add(id);

            Id = id;

        }
        public int Id { get; set; }
        public UserDbModel User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public int ReportId { get; set; }

        public DateTime PostedOn { get; set; }

        [Required]
        public string CommentContent { get; set; }
        public override string ToString()
        {
            return String.Format($"userId: {UserId}\r\nreportId: {ReportId}\r\npostedOn: {PostedOn}\r\ncommentContent: {CommentContent}");
        }
    }
}
