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

            CreateMap<Book, Book>().ForMember(dest => dest.Id, opt => opt.Ignore());

            //Category
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<GetAllCategoriesDto, Category>().ReverseMap();
            CreateMap<GetCategoryByIdDto, Category>().ReverseMap();

            CreateMap<Category, Category>().ForMember(dest => dest.Id, opt => opt.Ignore());

            //Customer
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<GetAllCustomersDto, Customer>().ReverseMap();
            CreateMap<GetCustomerByIdDto, Customer>().ReverseMap();

            CreateMap<Customer, Customer>().ForMember(dest => dest.Id, opt => opt.Ignore());
            //.ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember) => srcMember != null));


            //RentalBook
            CreateMap<CreateRentedBookDto, RentedBook>();
            CreateMap<UpdateRentedBookDto, RentedBook>();
            CreateMap<GetAllRentedBooksDto, RentedBook>().ReverseMap();
            CreateMap<GetRentedBookByIdDto, RentedBook>().ReverseMap();

            CreateMap<RentedBook, RentedBook>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
