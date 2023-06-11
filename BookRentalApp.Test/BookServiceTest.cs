using AutoMapper;
using BookRentalApp.Business;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Moq;
using System;
using Xunit;

namespace BookRentalApp.Test
{
    public class BookServiceTest
    {
        private BookService _service;
        private Mock<IBookRepository> _repository;
        private Mock<IMapper> _mapper;

        public BookServiceTest() 
        {
            _repository = new Mock<IBookRepository>();
            _mapper = new Mock<IMapper>();
            _service = new BookService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void UpdateSuccess()
        {
            //arrange
            var id = 9;
            var book = new UpdateBookDto
            {
                Title = "Suç ve Ceza",
                Author = "Fyodor Mihayloviç Dostoyevski",
                Publisher = "Ýþ Bankasý Kültür Yayýnlarý",
                ISBN = "",
                Page = 687,
                Price = 52.00,
                CategoryId = 8
            };

            _mapper.Setup(x => x.Map<Book>(It.IsAny<UpdateBookDto>())).
                Returns(new Book());

            _repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>())).
                Returns(new Data.Entity.Book());

            _repository.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Book>())).
                Returns(new Book());

            //act
            var response = _service.Update(id, book);

            //assert
            Assert.NotNull(response);
            Assert.IsType<ServiceResult<GetBookByIdDto>>(response);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Result);
            Assert.Empty(response.ErrorMessage);

        }

        [Fact]
        public void Update_WhenBookIsNotFound_ReturnFailed()
        {
            //arrange
            var id = 9;
            var book = new UpdateBookDto
            {
                Title = "Suç ve Ceza",
                Author = "Fyodor Mihayloviç Dostoyevski",
                Publisher = "Ýþ Bankasý Kültür Yayýnlarý",
                ISBN = "",
                Page = 687,
                Price = 52.00,
                CategoryId = 8
            };

            _mapper.Setup(x => x.Map<Book>(It.IsAny<UpdateBookDto>())).
                Returns(new Book());

            _repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>())).
                Returns((Book)null);

            //act
            var response = _service.Update(id, book);

            //assert
            Assert.NotNull(response);
            Assert.IsType<ServiceResult<GetBookByIdDto>>(response);
            Assert.False(response.IsSuccess);
            Assert.Null(response.Result);
            Assert.NotEmpty(response.ErrorMessage);

        }

        [Fact]
        public void Update_WhenRepoUpdateFailed()
        {
            //arrange
            var id = 9;
            var book = new UpdateBookDto
            {
                Title = "Suç ve Ceza",
                Author = "Fyodor Mihayloviç Dostoyevski",
                Publisher = "Ýþ Bankasý Kültür Yayýnlarý",
                ISBN = "",
                Page = 687,
                Price = 52.00,
                CategoryId = 8
            };

            _mapper.Setup(x => x.Map<Book>(It.IsAny<UpdateBookDto>())).
                Returns(new Book());

            _repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>())).
                Returns(new Data.Entity.Book());

            _repository.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Book>())).
                Returns((Book)null);

            //act
            var response = _service.Update(id, book);

            //assert
            Assert.NotNull(response);
            Assert.IsType<ServiceResult<GetBookByIdDto>>(response);
            Assert.False(response.IsSuccess);
            Assert.Null(response.Result);
            Assert.NotEmpty(response.ErrorMessage);

        }

        [Fact]
        public void Delete_WhenBookNotFound_ThrowException()
        {
            //arrange
            var id = 9;
            _repository.Setup(x => x.Delete(It.IsAny<int>())).Throws(new Exception(""));
                        
            //assert
            Assert.Throws<Exception>(() => _service.Delete(id));

        }
    }
}
