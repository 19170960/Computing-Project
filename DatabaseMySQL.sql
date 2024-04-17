CREATE TABLE message(messageID int NOT NULL, PRIMARY KEY (messageID), sender varchar(30) NOT NULL, body varchar(300) NOT NULL);
-- Create message table storing messages (containing ID, sender, and body information) ID is stored as an integer. Sender is stored as a string, with a limit of 30 characters. Body is stored as a string, with a limit of 300 characters.
-- SMS functionality could be improved to store message data (using this table.) This has not been implemented within the current system.

CREATE TABLE conversation(conversationID int NOT NULL, PRIMARY KEY (conversationID), messageID int NOT NULL, FOREIGN KEY (messageID) REFERENCES message(messageID));
-- Create conversation table storing conversations. Conversations contain a conversationID, and messageID. Both of these attributes are integers.
-- Conversations could be implemented within the application, in order to display different conversations (with included messages) on the application, for each user. However, this has not been implemented.

CREATE TABLE user(userID int NOT NULL, PRIMARY KEY (userID), username varchar(20) NOT NULL, password varchar(20) NOT NULL, conversationID int, FOREIGN KEY (conversationID) REFERENCES conversation(conversationID));
-- Create user table storing username, password and conversation IDs. Usernames, and passwords are stored as strings (with a character-length limit of 20.) Conversation ID is stored as an integer. This ID is not required when creating a user, as conversations are planned to be implemented so that they are added (when starting a conversation.) However, this feature has not been implemented.
-- User functionality could be improved to store different conversations (containing messages) for previous SMS communications. Functionality could be implemented in order to display this information on the application. However, it would also have to be stored by the application, beforehand.