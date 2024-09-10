namespace API_INTRO.DTOs.BookDTOs
{
    public record BookUpdateDto(string name, double costPrice, double salePrice, int genreId);

}
