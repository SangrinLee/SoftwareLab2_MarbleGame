USE 모두의마블

CREATE TABLE 멤버
(
	회원아이디		CHAR(20),
	이름			CHAR(20),
	비밀번호		CHAR(20),
	마일리지		INT, 
	
	PRIMARY KEY(회원아이디)
)

INSERT INTO 멤버 VALUES('APPLE', '사과', '1234', 200)
INSERT INTO 멤버 VALUES('BANANA', '바나나', '1234', 200)
INSERT INTO 멤버 VALUES('CAT', '고양이', '1234', 200)
INSERT INTO 멤버 VALUES('DOG', '개', '1234', 200)
INSERT INTO 멤버 VALUES('EGG', '달걀', '1234', 200)
INSERT INTO 멤버 VALUES('FIRE', '불', '1234', 200)
INSERT INTO 멤버 VALUES('GREEN', '초록', '1234', 200)
INSERT INTO 멤버 VALUES('HOUSE', '집', '1234', 200)

