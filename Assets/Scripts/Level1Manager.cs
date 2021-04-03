using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Level1Manager : MonoBehaviour
{





    [Header("Title Scene Properties", order = 0)]
    [Space(2f)]
    [Header("Intro Scene Properties", order = 1)]
    public GameObject introImage;
    public GameObject backButton;
    public GameObject nextButton;
    public Color backgroundColor;
    public TMP_Text introText;
    [Header("Tutorial Scene Properties", order = 2)]
    [Space(2f)]
    [Header("Level01 Scene Properties", order = 3)]


    int introSequence;
    Scene currentScene;

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case "00TitleScene":
                break;
            case "01IntroScene":
                introText.text = "Welcome to Simple Stocks\n\n" + "" +
                    "This game teaches the basics of the stock market, in a fun way!";
                introImage.SetActive(true);
                backButton.SetActive(false);
                break;
            case "02TutorialScene":
                break;
            case "03Level01":
                break;
        }

    }

    void SetIntroSequence()
    {
        switch (introSequence)
        {
            case 0:
                introText.fontSize = 32;
                introText.alignment = TextAlignmentOptions.Center;
                introText.text = "Welcome to Simple Stocks\n\n" + "" +
                    "This game teaches the basics of the stock market, in a fun way!\n\n\n\n\n";
                introImage.SetActive(true);
                backButton.SetActive(false);
                break;
            case 1:
                introText.fontSize = 32;
                introImage.SetActive(false);
                backButton.SetActive(true);
                introText.alignment = TextAlignmentOptions.Left;
                introText.text = "Overview\n\n" +
                    "Title: ​Simple Stocks\n" +
                    "Platform: ​ WebGL\n" +
                    "Subject: ​Economics\n" +
                    "Sub Subject: ​Investment\n" +
                    "Main Focus: ​Understanding Stock Market Basics\n" +
                    "Learning Level: ​Grades 9 - 12";
                break;
            case 2:
                introText.fontSize = 24;
                introText.text = "Proposed EdTech Solution\n\n" + "" +
                    "Many schools have economics courses, but these classes oftentimes have the issue of not discussing how these concepts apply to the real world. Economics is no different, with many general economics courses not discussing how fundamental economic principals affect a person's life. Additionally, a very important aspect of economics, the stock market, is often under-represented in high school classes, giving students no understanding of how to increase their wealth over time with investing. This tool would seek to simplify markets and make them easier to understand, and would go over other stock market tools such as shorts, call options, and put options.";
                break;
            case 3:
                introText.fontSize = 20;
                introText.text = "Competing Software Review\n\n" +
                    "How The Market Works - An online application that allows users to invest virtual money into the real stock market in order to learn how their choices affect their portfolio. Competitions are available so users can see how well they are doing compared to others.\n\n" +
                    "Investopedia - A website with a large amount of learning material available so that students and users can better understand the stock market. Also has games and competitions where users can invest virtual money to improve their financial skills.\n\n" +
                    "The Stock Market Game - A program meant for teachers to use with their classes to show them how to properly invest their money. Has a virtual market, as well as resources and a support center to help educators.";
                break;
            case 4:
                introText.fontSize = 20;
                introText.text = "Competing Software Suggested Improvements\n\n" +
                    "Too Many Choices- All of these software use the real world stock market for their virtual simulations, and although this can be useful, the real stock market can get overwhelming very quickly due to the large amount of stocks available to trade. Because of this, it can be hard for a student to know where to start investing.\n\n" +
                    "No Long-Term Feedback- Additionally, because of the use of the real world stock market in these apps, it is extremely difficult to know how one's choices would do in the long term. For stocks, many choices are made with long-term goals in mind, so having to wait large amounts of real time in order to get results can slow down learning drastically.\n\n" +
                    "Little Direction- These programs offer no help in showing what stocks may be good to invest in, meaning the user has to do a large amount of outside research. This lack of direction can make it harder for users to engage with the system.";
                break;
            case 5:
                introText.fontSize = 32;
                introText.text = "Stakeholders & Users\n\n" +
                    "Teachers\nParents\nStudents: High School, Grades 9 - 12";
                break;
            case 6:
                introText.fontSize = 20;
                introText.text = "Persona\n\n" +
                    "Name: John\n" +
                    "Age: 16 years old\n" +
                    "Gender: Male\n" +
                    "Location: Suburban USA\n\n" +
                    "Personal Notes:\nLike playing video games in his spare time\nHas a summer job to make some extra money\n\n" +
                    "Student Notes:\nWants to have a better understanding of the stock market, but finds it too complicated\nFinds many other stock market learning tools are full of concepts he doesn’t understand\nWants a way of learning that makes it into a game\nDoes not know how to use stocks for long-term gains";
                break;
            case 7:
                introText.text = "Justification of Persona Decisions:\n\n" +
                    "I built this persona because I feel that it has much in common with both myself, and with many other people who live in suburban America. In most high schools, there aren’t any classes that teach people how to invest in stocks, what stocks might be good at the time, and where to find information about different stocks. Because of this, many students start investing much later in life, which can significantly hurt the amount of money that a person makes from the stock market. This persona is one that encompases a lot of very common traits in these types of students.";
                break;
            case 8:
                introText.fontSize = 20;
                introText.text = "Problem Scenario\n\n" +
                    "After making a decent amount of money working over the summer, John wants to find a good use for it. He doesn’t have anything that he wants to buy at the moment, so he decides to save the money, and has heard that investing is a good way to increase the amount of money that one has. He has taken a basic economics class before, so he wants to see if he can apply this knowledge to the stock market as well. John’s parents have their financial advisor invest their money for them, so they do not know enough about the market to help John with his money.\n\n" +
                    "After searching around on the internet, John finds a few tools that can help him understand the market. However, these tools do not give John much of a sense of direction, and with the amount of information available on these sites, John gets overwhelmed. There are simply too many stocks to choose from, and too many ways that he can invest his money. After unsuccessfully trying to understand how the market works, John decides it would just be easier to keep his money in a bank account, losing him the opportunity to increase his savings though the market.";
                break;
            case 9:
                introText.fontSize = 20;
                nextButton.SetActive(true);
                introText.text = "Activity Scenario\n\n" +
                    "After talking to a few friends about his difficulties with investing, one of them tells John about a new program that he used to teach the basics of the stock market. John decides to download the program, and is pleased to learn that this program starts off very simply, with only the ability to buy and sell stocks, and with only one fake company. Additionally, John does not have to worry about losing any money, because the game uses a fake currency. Finally, John notices that as the game goes on, more companies get added, meaning he has more options for investing his in-game money.\n\n" +
                    "After a few weeks of playing this game, John feels that he is confident enough to start investing in the stock market. The game has taught him how investing works, as well as what information he should look for when trying to find a company to invest in. John also learned the value of diversifying his portfolio, preventing all his savings from being lost should one of the companies he invests in have a bad few months. Using this information, John starts investing, and after a few years, realizes that the money he made can be used to help pay off his college tuition.";
                break;
            case 10:
                introText.fontSize = 22;
                nextButton.SetActive(false);
                introText.text = "Problem Statement\n\n" +
                    "John wants to invest his savings into the stock market, but doesn’t want to do it until he knows how the market functions, because he is afraid of losing the money he worked all summer for. Additionally, he doesn’t have any way to learn how to invest, and nobody he knows is knowledgeable enough about the market to teach him. After finding a new program, John learns how investing works, what kinds of signs to look for in good stocks, and has learned from the mistakes he made in this stock game so he will not make them with his real money. Now John feels confident to invest his own money in the market, and knows that even if he makes some unfavorable trades, he will still be able to increase his savings over time.";
                break;
        }
    }

    public void IntroSequenceBack()
    {
        introSequence--;
        SetIntroSequence();
    }

    public void IntroSequenceNext()
    {
        introSequence++;
        SetIntroSequence();
    }

}