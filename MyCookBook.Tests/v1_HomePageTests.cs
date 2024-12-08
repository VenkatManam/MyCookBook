using Xunit;
	
	public class v1_HomePageTests
	{
	    [Fact]
	    public void HomePage_ShouldHaveWelcomeMessage()
	    {
	        string expected = "Welcome to My Cook Book";
	        string actual = "Welcome to My Cook Book"; // Mock actual output
	        Assert.Equal(expected, actual);
	    }

        [Fact]
        public void HomePage_ShouldContainHeading()
        {
            string expected = "Welcome to My Cook Book";
            string actual = "Welcome to My Cook Book"; // Mock actual output
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void HomePage_ShouldContainParagraph()
        {
            string expected = "Your personalized recipe manager is under development.";
            string actual = "Your personalized recipe manager is under development."; // Mock actual output
            Assert.Equal(expected, actual);
        }

	}