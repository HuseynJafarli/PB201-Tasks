namespace API_INTRO.DTOs.BookDTOs
{
    public record BookCreateDto(string name, double costPrice, double salePrice, int genreId);

}
