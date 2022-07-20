using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<CommentDto>> GetAllDto();
        IDataResult<Comment> GetById(int commentId);
        IDataResult<List<Comment>> GetAllByProductId(int id);
        IDataResult<List<CommentDto>> GetCommentDtoByProductId(int id);
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Hidden(List<int> id);
        IResult Delete(Comment comment);

    }
}
