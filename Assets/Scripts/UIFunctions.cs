using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UIFunctions : MonoBehaviour
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
    public GameObject backButton1;
    public GameObject nextButton1;
    public GameObject buyButton, sellButton, returnButton;
    public GameObject testChart;
    public TMP_Text level1Text;
    public TMP_Text moneyText;
    public TMP_Text sharesText;
    public TMP_Text totalMoneyText;
    public GameObject circlePrefab;
    public GameObject cylPrefab;
    public GameObject line1;
    public GameObject line2;


    Vector3 pos, pos2;

    int introSequence;
    int level1Progress;
    int tutorialProgress;

    int money;
    int shares;
    int currentPrice;
    bool passed;

    int minHeight = -33;
    int minWidth = -110;
    int maxHeight = 45;
    int maxWidth = 120;

    int[] priceArray = { 10, 12, 15, 20, 17, 19, 24, 28, 22, 24, 30 };
    int[] priceArrayTutorial = { 15, 22, 25, 20, 17, 10, 12, 17, 19, 25, 30 };

    Scene currentScene;

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        GameObject currentSphere;

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
                level1Text.fontSize = 20;
                level1Text.alignment = TextAlignmentOptions.Center;
                level1Text.text = "Welcome to Simple Stocks!\nIn this tutorial, will be going over how to navigate through this program and use it to learn about stocks.\n" +
                    "To continue, press the NEXT button below.";

                buyButton.SetActive(false);
                sellButton.SetActive(false);
                backButton1.SetActive(false);
                returnButton.SetActive(false);
                testChart.SetActive(false);

                money = 100;
                passed = false;

                for (int i = 0; i < priceArrayTutorial.Length; i++)
                {
                    pos = new Vector3(minWidth + ((maxWidth - minWidth) / 10) * i,
                        minHeight + ((maxHeight - minHeight)) * (priceArrayTutorial[i] - 10) / 20,
                        0);



                    currentSphere = Instantiate(circlePrefab, pos, Quaternion.identity);

                    currentSphere.transform.SetParent(line1.transform);

                    if (i != 0)
                    {

                        GameObject cyl = CreateCylinderBetweenPoints(pos, pos2, 8);

                        cyl.transform.SetParent(line1.transform);
                    }

                    pos2 = pos;
                }
                break;
            case "03Level01Scene":
                level1Text.fontSize = 32;
                level1Text.alignment = TextAlignmentOptions.Center;
                level1Text.text = "In order to start understanding what the stock market is and how it works, we first need to discuss what a stock even is.";

                buyButton.SetActive(false);
                sellButton.SetActive(false);
                backButton1.SetActive(false);
                returnButton.SetActive(false);
                testChart.SetActive(false);

                money = 100;
                passed = false;

                for (int i = 0; i < priceArray.Length; i++)
                {
                    pos = new Vector3(minWidth + ((maxWidth - minWidth) / 10) * i,
                        minHeight + ((maxHeight - minHeight)) * (priceArray[i] - 10) / 20,
                        0);



                    currentSphere = Instantiate(circlePrefab, pos, Quaternion.identity);

                    currentSphere.transform.SetParent(line1.transform);

                    if (i != 0)
                    {

                        GameObject cyl = CreateCylinderBetweenPoints(pos, pos2, 8);

                        cyl.transform.SetParent(line1.transform);
                    }

                    pos2 = pos;
                }
                break;
        }

    }

    GameObject CreateCylinderBetweenPoints(Vector3 start, Vector3 end, float width)
    {
        var offset = end - start;
        var scale = new Vector3(width, offset.magnitude / 2.0f, width);
        var position = start + (offset / 2.0f);

        var cylinder = Instantiate(cylPrefab, position, Quaternion.identity);
        cylinder.transform.up = offset;
        cylinder.transform.localScale = scale;

        return (GameObject)cylinder;
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

    //Code for level 1 buttons, don't feel like reinventing the wheel


    void SetLevel1Text()
    {
        GameObject currentSphere;

        switch (level1Progress)
        {
            case 0:
                level1Text.fontSize = 32;
                level1Text.alignment = TextAlignmentOptions.Center;
                level1Text.text = "In order to start understanding what the stock market is and how it works, we first need to discuss what a stock even is.";
                backButton1.SetActive(false);
                break;
            case 1:
                level1Text.fontSize = 24;
                backButton1.SetActive(true);
                level1Text.alignment = TextAlignmentOptions.Left;
                level1Text.text = "In its simplest form, a stock is just a small piece of a company. When you buy a stock, you are purchasing a small part of whatever company created that stock, called a share. "
                     + "For example, if you purchase one share of Coca-Cola, you then own a tiny part of that company.";
                break;
            case 2:
                level1Text.fontSize = 24;
                level1Text.text = "The reason this is important is because when a company is doing well, the price of all the shares of that company increase, and if you own a share of that company, you can then sell the share for more than you originally purchased it for, meaning you make money.";
                break;
            case 3:
                level1Text.fontSize = 20;
                level1Text.text = "This leads to our first concept of buying stocks: buy low and sell high. If you buy 10 shares of a company, let's call them ABC, for $10 a share, you will spend $100 in total. Then, 1 year later, the price of a single share of ABC is $20. If you sell all 10 of your shares, you will end up with $200, $100 more than you started with.";
                break;
            case 4:
                level1Text.fontSize = 32;
                testChart.SetActive(false);
                level1Text.text = "Now, let's go over how to know you can know the price of a stock for any company.";
                break;
            case 5:
                level1Text.fontSize = 20;
                testChart.SetActive(true);
                level1Text.text = "Below, you can see a table with a line and some numbers on it. This is called a stock chart. This is the most common tool you are going to see as you start off with investing. This chart shows how the price of a stock changes over time. The actual time frame will vary between charts, and it should say the time frame on whatever chart you are looking at.";
                break;
            case 6:
                level1Text.fontSize = 18;
                level1Text.text = "The line on the chart shows the current price of the stock. On Monday, XYZ started just at $10. Then it rose to about $22, before falling back down to 17 on Tuesday. From Tuesday to Wednesday, XYZ slowly grew to about $28, before quickly dropping back down to around $22 at the start of Thursday. Then, XYZ quickly grew to about $30 by Friday. If you buy a share of XYZ when the line is low, and then sell it when the line is higher, you will make a profit.";
                break;
            case 7:
                level1Text.fontSize = 24;

                level1Text.text = "There are many great places to find these charts, but websites like Yahoo Finance (finance.yahoo.com) are great places for beginners to start!";
                break;
            case 8:
                level1Text.fontSize = 20;
                level1Text.alignment = TextAlignmentOptions.Left;
                buyButton.SetActive(false);
                sellButton.SetActive(false);
                line1.SetActive(true);
                backButton1.SetActive(true);
                level1Text.text = "In a moment, we are going to go through this chart step by step, and you will be able to buy and sell shares of XYZ at every step of the way. Do your best to make as much money as possible! You will start with $100, and XYZ's start price will be $10. In order to pass, you need to have at least $150 at the end of the in-game week.";
                break;
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:

                line1.SetActive(false);
                nextButton1.SetActive(true);
                returnButton.SetActive(false);

                foreach (Transform child in line2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                for (int i = 0; i < level1Progress - 8; i++)
                {
                    pos = new Vector3(minWidth + ((maxWidth - minWidth) / 10) * i,
                        minHeight + ((maxHeight - minHeight)) * (priceArray[i] - 10) / 20,
                        0);



                    currentSphere = Instantiate(circlePrefab, pos, Quaternion.identity);

                    currentSphere.transform.SetParent(line2.transform);

                    if (i != 0)
                    {

                        GameObject cyl = CreateCylinderBetweenPoints(pos, pos2, 8);

                        cyl.transform.SetParent(line2.transform);
                    }

                    pos2 = pos;
                }

                level1Text.fontSize = 20;
                buyButton.SetActive(true);
                sellButton.SetActive(true);
                backButton1.SetActive(false);
                level1Text.alignment = TextAlignmentOptions.Center;
                currentPrice = priceArray[level1Progress - 9];
                level1Text.text = "Available Money: $" + money + "\nPrice Per Share: $" + currentPrice + "\nShares Owned: " + shares + "\nTotal Value: $" + (money + shares * currentPrice);
                break;
            case 20:
                returnButton.SetActive(true);
                nextButton1.SetActive(false);
                if ((money + shares * currentPrice) > 150)
                {
                    passed = true;
                }

                if (passed)
                {
                    level1Text.fontSize = 22;
                    buyButton.SetActive(false);
                    sellButton.SetActive(false);

                    level1Text.text = "Hopefully this gives you a good idea of how buying stocks can make you money. If you want, you can go back and try to make even more money, or you can just experiment and see what you can do!\n\nTotal Money: $" + (money + shares * currentPrice);

                }
                else
                {
                    level1Text.text = "Sadly, you haven't made enough money to pass. Don't worry though, you can go to the start of the week using the 'Go Back' button and try again!";
                }

                break;
        }
    }

    public void Level1Back()
    {
        level1Progress--;
        SetLevel1Text();
    }

    public void Level1Next()
    {
        level1Progress++;
        SetLevel1Text();
    }

    public void Level1Return()
    {
        level1Progress = 9;
        shares = 0;
        money = 100;

        SetLevel1Text();
    }

    public void BuyShare()
    {
        if (money >= currentPrice)
        {
            money -= currentPrice;
            shares++;
        }
        SetLevel1Text();
    }

    public void SellShare()
    {
        if (shares > 0)
        {
            money += currentPrice;
            shares--;
        }
        SetLevel1Text();
    }



    void SetTutorialText()
    {
        GameObject currentSphere;

        switch (tutorialProgress)
        {
            case 0:
                level1Text.fontSize = 20;
                level1Text.alignment = TextAlignmentOptions.Center;
                level1Text.text = "Welcome to Simple Stocks!\nIn this tutorial, will be going over how to navigate through this program and use it to learn about stocks.\n" +
                    "To continue, press the NEXT button below.";
                backButton1.SetActive(false);
                break;
                
            case 1:
                level1Text.fontSize = 32;
                level1Text.alignment = TextAlignmentOptions.Center;
                level1Text.text = "At any point in this tutorial, if you wish to go back to the main menu, you can press the HOME on the bottom left of your screen";
                backButton1.SetActive(true);

                break;
            case 2:
                level1Text.fontSize = 32;
                level1Text.alignment = TextAlignmentOptions.Left;
                level1Text.text = "If you would like to go back to the last text box, you can press the BACK button below as well.";
                break;
            case 3:
                level1Text.fontSize = 32;
                level1Text.text = "For each level, a stock market concept will be defined and discussed. For instance, in level 1, we will be discussing stocks, and how you can use them to make money for yourself.";
                break;
            case 4:
                level1Text.fontSize = 32;
                testChart.SetActive(false);
                level1Text.text = "With each new concpet that is introduced, you will be given a short game related to that topic to help you understand it better.";
                break;
            case 5:
                level1Text.fontSize = 32;
                testChart.SetActive(true);
                level1Text.text = "Each level will have its own game, but most likely, you will see a stock market chart below. Don't worry about what this means just yet, we will be going over that in the next level.";
                break;
            case 6:
                level1Text.fontSize = 20;
                level1Text.text = "When the game starts, you will see different buttons appear on this screen corresponding to the concept that is being taught. For instance, in the first level, buttons to buy and sell stocks will appear. You don't have to worry about the prices since all of the money used in this game is fake, so if you lose money here, it's okay!";
                break;
            case 7:
                level1Text.fontSize = 24;

                level1Text.text = "Each level will have a goal for how much money you need to make (or not lose) in order to move on to the next level. If you don't pass a level the first time, you can always go back and restart it to try and get a better score!";
                break;
            case 8:
                level1Text.fontSize = 24;
                level1Text.alignment = TextAlignmentOptions.Left;
                line1.SetActive(true);
                backButton1.SetActive(true);
                level1Text.text = "On the next screen, the game for this level is going to start. Since we haven't introduced any concepts yet, you can just click NEXT and watch as the chart below changes over time.";
                break;
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:

                line1.SetActive(false);
                nextButton1.SetActive(true);
                returnButton.SetActive(false);

                foreach (Transform child in line2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                for (int i = 0; i < tutorialProgress - 8; i++)
                {
                    pos = new Vector3(minWidth + ((maxWidth - minWidth) / 10) * i,
                        minHeight + ((maxHeight - minHeight)) * (priceArrayTutorial[i] - 10) / 20,
                        0);



                    currentSphere = Instantiate(circlePrefab, pos, Quaternion.identity);

                    currentSphere.transform.SetParent(line2.transform);

                    if (i != 0)
                    {

                        GameObject cyl = CreateCylinderBetweenPoints(pos, pos2, 8);

                        cyl.transform.SetParent(line2.transform);
                    }

                    pos2 = pos;
                }

                level1Text.fontSize = 32;
                backButton1.SetActive(false);
                level1Text.alignment = TextAlignmentOptions.Center;
                currentPrice = priceArray[tutorialProgress - 9];
                level1Text.text = "Have fun looking at how the chart below changes over time. Take your time to get use to the menus and the game!";
                break;
            case 20:
                level1Text.fontSize = 24;
                nextButton1.SetActive(false);
                level1Text.text = "I hope this tutorial was helpful for you! In the next level, we are going to go over the most important concept in the market: stocks! In order to go back to the main menu, press the HOME button on the bottom left of your screen!";

                break;
        }
    }

    public void TutorialBack()
    {
        tutorialProgress--;
        SetTutorialText();
    }

    public void TutorialNext()
    {
        tutorialProgress++;
        SetTutorialText();
    }
}