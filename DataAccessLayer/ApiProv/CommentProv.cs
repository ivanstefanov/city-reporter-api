using DataAccessLayer.DbProv;
using DataAccessLayer.Models;
using DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ApiProv
{
    public class CommentProv
    {
        private readonly CommentContext _context;
        private readonly UserContext _userContext;

        public CommentProv(CommentContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }
        public async Task CreateComment(Comment comment)
        {
            if (comment == null)
            {
                throw new NullReferenceException("comment is null");
            }

            UserDbModel commentUser = await _userContext.Read(comment.UserId);

            if (commentUser is null)
            {
                throw new NullReferenceException("user is null");
            }

            CommentDbModel newComment = new CommentDbModel(comment.UserId, comment.ReportId, comment.PostedOn, comment.CommentContent, commentUser);

            await _context.Create(newComment);
        }
        public async Task<Comment> ReadComment(int key)
        {
            CommentDbModel commentFromDb = await _context.Read(key, true, false);

            if (commentFromDb is null)
            {
                throw new NullReferenceException("Comment with such a key doesn't exist");
            }

            Comment comment = new Comment(commentFromDb.Id, commentFromDb.UserId, commentFromDb.ReportId, commentFromDb.PostedOn, commentFromDb.CommentContent);

            return comment;
        }
        public async Task<List<Comment>> ReadAllComments()
        {
            List<CommentDbModel> commentsFromDb = await _context.ReadAll(true, false);

            if (commentsFromDb is null)
            {
                throw new NullReferenceException("Our app doesn't have comments");
            }

            List<Comment> comments = commentsFromDb.
                Select(cd => new Comment(cd.Id, cd.ReportId, cd.UserId, cd.PostedOn, cd.CommentContent)).ToList();

            return comments;
        }
        public async Task UpdateComment(Comment comment)
        {
            if (comment is null)
            {
                throw new NullReferenceException("Comment doesn't exist");
            }

            if (comment.UserId == 0)
            {
                throw new NullReferenceException("User doesn't exist");
            }

            UserDbModel userFromDb = await _userContext.Read(comment.UserId);

            CommentDbModel dbComment = new CommentDbModel
                (comment.UserId, comment.ReportId, comment.PostedOn, comment.CommentContent, userFromDb);
            dbComment.Id = comment.Id;

            await _context.Update(dbComment, true);
        }
        public async Task DeleteComment(int key)
        {
            _context.Delete(key);
        }
    }
}
