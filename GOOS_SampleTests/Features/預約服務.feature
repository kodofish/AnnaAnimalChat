@web
Feature: 預約服務
	為了能夠事先預定溝通時間
	身為一個要能夠請安娜一起來聊天的使用者
	我需要一個能夠預約溝通時間的表單


Scenario: 預約線上文字聊天一小時, 並有兩個寵物同伴, 希望預約在平日下午12:00~13:30
	Given 開啟 "to Book 來聊愛" 頁面
	And 我必須先填寫基本資料
		| FullName | LineId   | Claim | Family | AnimalStatus | AnimalAmount | A_AnimalName | A_AnimalPic | B_AnimalName | B_AnimalPic |
		| 魚尾       | Kodofish | 拔巴    |        | 在世           | 2            |斑斑           | 斑斑.jpg       | 小虎          | 小虎.jpg       |
	And 選擇聊天方式 "線上文字訊息", 聊天時間 "1hr"
	And 預約的時段選擇 "平日 下午12:00~13:30"
	When 當我按下確認表單後
	Then 應該能得到 "送出成功" 的訊息
