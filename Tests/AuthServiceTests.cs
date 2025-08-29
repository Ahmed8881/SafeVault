using Xunit;
using SafeVault.Services;

namespace SafeVault.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void HashPassword_ReturnsConsistentHash()
        {
            var service = new AuthService();
            var hash1 = service.HashPassword("securePassword");
            var hash2 = service.HashPassword("securePassword");
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void ValidatePassword_ReturnsTrueForCorrectPassword()
        {
            var service = new AuthService();
            var hash = service.HashPassword("securePassword");
            Assert.True(service.ValidatePassword("securePassword", hash));
        }

        [Fact]
        public void ValidatePassword_ReturnsFalseForIncorrectPassword()
        {
            var service = new AuthService();
            var hash = service.HashPassword("securePassword");
            Assert.False(service.ValidatePassword("wrongPassword", hash));
        }
    }
}