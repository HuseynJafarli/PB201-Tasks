namespace API_INTRO.DTOs.BookDTOs
{
    public record BookGetDto(int id, string name, double costPrice, double salePrice, int genreId, string genreName);
}
