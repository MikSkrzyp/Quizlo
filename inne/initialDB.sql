IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE Users (
        UserID INT PRIMARY KEY IDENTITY,
        Username NVARCHAR(50) NOT NULL,
        Password NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100),
        DateRegistered DATETIME
    );
    PRINT 'Users table created successfully.'
END
ELSE
BEGIN
    PRINT 'Users table already exists.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Quizzes')
BEGIN
    CREATE TABLE Quizzes (
        QuizID INT PRIMARY KEY IDENTITY,
        Title NVARCHAR(100) NOT NULL,
        Description NVARCHAR(MAX),
        CreatorID INT,
        DateCreated DATETIME,
        FOREIGN KEY (CreatorID) REFERENCES Users(UserID)
    );
    PRINT 'Quizzes table created successfully.'
END
ELSE
BEGIN
    PRINT 'Quizzes table already exists.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Questions')
BEGIN
    CREATE TABLE Questions (
        QuestionID INT PRIMARY KEY IDENTITY,
        QuizID INT,
        QuestionText NVARCHAR(MAX),
        QuestionType NVARCHAR(50),
        FOREIGN KEY (QuizID) REFERENCES Quizzes(QuizID)
    );
    PRINT 'Questions table created successfully.'
END
ELSE
BEGIN
    PRINT 'Questions table already exists.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Answers')
BEGIN
    CREATE TABLE Answers (
        AnswerID INT PRIMARY KEY IDENTITY,
        QuestionID INT,
        AnswerText NVARCHAR(MAX),
        IsCorrect BIT,
        FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)
    );
    PRINT 'Answers table created successfully.'
END
ELSE
BEGIN
    PRINT 'Answers table already exists.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'QuizAttempts')
BEGIN
    CREATE TABLE QuizAttempts (
        AttemptID INT PRIMARY KEY IDENTITY,
        QuizID INT,
        UserID INT,
        Score INT,
        AttemptDate DATETIME,
        FOREIGN KEY (QuizID) REFERENCES Quizzes(QuizID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'QuizAttempts table created successfully.'
END
ELSE
BEGIN
    PRINT 'QuizAttempts table already exists.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AttemptedQuestions')
BEGIN
    CREATE TABLE AttemptedQuestions (
        AttemptID INT,
        QuestionID INT,
        FOREIGN KEY (AttemptID) REFERENCES QuizAttempts(AttemptID),
        FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)
    );
    PRINT 'AttemptedQuestions table created successfully.'
END
ELSE
BEGIN
    PRINT 'AttemptedQuestions table already exists.'
END
GO
