Feature: 費用計算
	為了能夠正確計算費用
	身為想請安娜進行寵物溝通的家長
	我希望能夠告訴我該支付多少費用


Scenario: Line 文字訊息, 0.5 hr
	Given 選擇Line文字訊息
	And 交談時數選 0.5 hr
	When 計算費用
	Then 應得到 600 元

Scenario: Line 文字訊息, 1 hr
	Given 選擇Line文字訊息
	And 交談時數選 1 hr
	When 計算費用
	Then 應得到 1000 元


Scenario: Line 文字訊息, 1.5 hr
	Given 選擇Line文字訊息
	And 交談時數選 1.5 hr
	When 計算費用
	Then 應得到 1300 元

Scenario: Line 文字訊息, 0.5 hr, 寵物狀態是往生小天使
	Given 選擇Line文字訊息
	And 交談時數選 0.5 hr
	And 寵物狀態是往生小天使
	When 計算費用
	Then 應得到 900 元

Scenario: Line 文字訊息, 1 hr, 寵物狀態是往生小天使
	Given 選擇Line文字訊息
	And 交談時數選 1 hr
	And 寵物狀態是往生小天使
	When 計算費用
	Then 應得到 1300 元


Scenario: Line 文字訊息, 1.5 hr, 寵物狀態是往生小天使
	Given 選擇Line文字訊息
	And 交談時數選 1.5 hr
	And 寵物狀態是往生小天使
	When 計算費用
	Then 應得到 1600 元


Scenario: 面對面溝通, 1 hr
	Given 選擇面對面溝通
	And 交談時數選 1 hr
	When 計算費用
	Then 應得到 1200 元

Scenario: 面對面溝通, 1.5 hr
	Given 選擇面對面溝通
	And 交談時數選 1.5 hr
	When 計算費用
	Then 應得到 1500 元

Scenario: 面對面溝通, 1 hr, 寵物狀態是往生小天使
	Given 選擇面對面溝通
	And 交談時數選 1 hr
	And 寵物狀態是往生小天使
	When 計算費用
	Then 應得到 1500 元

Scenario: 面對面溝通, 1.5 hr, 寵物狀態是往生小天使
	Given 選擇面對面溝通
	And 交談時數選 1.5 hr
	And 寵物狀態是往生小天使
	When 計算費用
	Then 應得到 1800 元


Scenario: 家訪, 1.5 hr
	Given 選擇家訪
	And 交談時數選 1.5 hr
	When 計算費用
	Then 應得到 2000 元

Scenario: 家訪, 1.5 hr, 寵物狀態是往生小天使
	Given 選擇家訪
	And 交談時數選 1.5 hr
	And 寵物狀態是往生小天使
	When 計算費用
	Then 應得到 2300 元