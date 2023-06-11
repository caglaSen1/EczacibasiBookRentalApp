using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Npgsql.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(CreateBookDto book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllBooksDto> GetAll(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public GetBookByIdDto GetById(int id, bool withCategory = false)
        {
            return _mapper.Map<GetBookByIdDto>(_repository.GetById(id, withCategory));
        }

        public List<GetBookByIdDto> Search(string title, int? categoryId, double? minPrice)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<GetBookByIdDto> Update(int id, UpdateBookDto book)
        {
            var b = GetById(id);

            if(b is null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Book not found", 344);
            }

            var bo = _repository.Update(id, _mapper.Map<Book>(book));

            if(bo is null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Book not found", 344);
            }

            return ServiceResult<GetBookByIdDto>.Success(_mapper.Map<GetBookByIdDto>(bo));
        }
    }
}
