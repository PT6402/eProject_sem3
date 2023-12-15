namespace Api.Service.Password
{
    public record PasswordResult
    (byte[] PasswordHash,
         byte[] PasswordSalt);
}
