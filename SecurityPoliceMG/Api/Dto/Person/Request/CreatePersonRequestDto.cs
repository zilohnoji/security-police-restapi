namespace SecurityPoliceMG.Dto.Person.Request;

public record CreatePersonRequestDto(string Name, string BirthDate, string Gender, string MotherName, string DaddyName);