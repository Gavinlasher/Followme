CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE Table if NOT Exists follows(
  id int  NOT NULL AUTO_INCREMENT PRIMARY KEY,
  following VARCHAR(355) NOT NULL,
  follower VARCHAR(355) NOT NULL,
  FOREIGN KEY (following) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (follower) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';