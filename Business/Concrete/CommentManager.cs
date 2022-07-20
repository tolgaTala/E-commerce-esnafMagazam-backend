using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            comment.Status = true;
            comment.CommentDate = DateTime.Now;
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(), Messages.CommentListed);
        }

        public IDataResult<List<Comment>> GetAllByProductId(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c=>c.ProductID==id), Messages.CommentListed);

        }

        public IDataResult<List<CommentDto>> GetAllDto()
        {
            return new SuccessDataResult<List<CommentDto>>(_commentDal.GetCommentDtoByProductId());

        }

        public IDataResult<Comment> GetById(int commentId)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c=>c.CommentID==commentId));
        }

        public IDataResult<List<CommentDto>> GetCommentDtoByProductId(int id)
        {
            return new SuccessDataResult<List<CommentDto>>(_commentDal.GetCommentDtoByProductId(c=>c.ProductId==id), "comment dto geldi");

        }

        public IResult Hidden(List<int> id)
        {
            foreach (var i in id)
            {
                var comment = _commentDal.Get(x=>x.CommentID==i);
                comment.Status = false;
                _commentDal.Update(comment);
            }
            return new SuccessResult();
        }

        public IResult Update(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            _commentDal.Update(comment);
            return new SuccessResult();
        }
    }
}
