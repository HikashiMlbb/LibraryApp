namespace LibraryApp.Domain.Shared;

public sealed record Error(string Code, string? Message = null);