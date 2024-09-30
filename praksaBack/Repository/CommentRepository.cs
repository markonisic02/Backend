using Microsoft.EntityFrameworkCore;
using praksaBack.Data;
using praksaBack.Interfaces;
using praksaBack.Models;

namespace praksaBack.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existsingComment = await _context.Comments.FindAsync(id);
            if (existsingComment == null)
            {
                return null;
            }
            existsingComment.Title = commentModel.Title;
            existsingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return existsingComment;
        }
    }
}