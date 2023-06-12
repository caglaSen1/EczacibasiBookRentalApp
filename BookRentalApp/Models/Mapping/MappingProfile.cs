using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Dto.BookRental;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Dto.Customer;
using BookRentalApp.Data.Entity;

namespace BookRentalApp.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Book
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<GetAllBooksDto, Book>().ReverseMap();
            CreateMap<GetBookByIdDto, Book>().ReverseMap();

            //Category
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<GetAllCategoriesDto, Category>().ReverseMap();
            CreateMap<GetCategoryByIdDto, Category>().ReverseMap();

            //Customer
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<GetAllCustomersDto, Customer>().ReverseMap();
            CreateMap<GetCustomerByIdDto, Customer>().ReverseMap();

            //RentalBook
            CreateMap<CreateRentedBookDto, RentedBook>();
            CreateMap<UpdateRentedBookDto, RentedBook>();
            CreateMap<GetAllRentedBooksDto, RentedBook>().ReverseMap();
            CreateMap<GetRentedBookByIdDto, RentedBook>().ReverseMap();
        }
    }
}
