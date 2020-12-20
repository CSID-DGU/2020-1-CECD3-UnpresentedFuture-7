# 2020-1-CECD3-UnpresentedFuture-7

### 2020 컴퓨터 종합설계 프로젝트
- VR과 LeapMotion을 사용한 boxing game 개발

## 개요
- 사용자 손 입력 장치와 AR 결합으로 몰입감 있는 운동 환경을 제공하며,    
- 스마트폰의 카메라와 디스플레이를 이용해 AR 환경을 구축하여 비싼 AR 장비 없이도 시간과 장소에 구애 받지 않고 AR 환경에 쉽게 접근할 수 있게 한다.    

## 설명
- 본 프로젝트는 크게 4가지 구성을 가지고 있다.    
- 게임 시작 기능, 난이도 조절 기능, 점수 기록 저장 기능, 게임 설정 기능으로 구성된다.    
- 게임의 시작 부분은 새로운 게임을 시작하거나 기존에 저장된 게임 데이터를 불러오는 기능을 담당한다.    
- 난이도 조절 기능은 게임의 난이도를 선택하는 기능으로 기본적으로 3가지로 분류되며 각각의 난이도에 따라 타격 오브젝트의 생성 속도, 이동 속도 등일 다양하게 설정된다.    
- 점수 기록 저장 기능은 게임이 종료될 때 최종 점수를 저장하며 여태까지 저장된 점수 기록들에 저장되고 정렬된다. 이후 사용자가 랭킹을 확인하면 어느 날짜에 얼마의 점수를 획득하고 전체적으로 등수가 어떻게 되는지가 출력된다.    
- 마지막으로 게임 설정 기능은 게임의 다양한 요소를 설정한다. 게임 재실행, 난이도 재설정, 게임 종료 등의 옵션이 존재한다.    

## 개발환경
- unity, visual studio, android

## 설치
1. Clone git repository.

```
git clone <https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7.git
```

2. Install required packages

Leap Motion, Firebase Database SDK, Tensorflow, ML Agent..

- Unity can download [here](https://unity3d.com/kr/get-unity/download)
- Firebase SDK can download [here](https://firebase.google.com/?hl=ko)
- MLAgent can download [here](https://drive.google.com/file/d/1GTOi52gW7_3QxeoTwWI33EacwGto112D/view?usp=sharing)    
- 안드로이드 디바이스에서 립모션을 사용하기 위해 필요한 LeapDaemon-release-2.3.2+35031.apk는 allip1004@gmail.com에 요청하여 받을 수 있다.    

3. Run Unity

connect your mobile device(it's cpu should be under than 810, 815) with Leap Motion.
after get sign that connect device with leap motion as well, you can play it!

## 사용 방법
title |  Iamge | Description 
:----:|:---------:|:------:|
 게임 스타트 화면 | ![사진](https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7/blob/master/Project%20Img/%E1%84%89%E1%85%B3%E1%84%8F%E1%85%B3%E1%84%85%E1%85%B5%E1%86%AB%E1%84%89%E1%85%A3%E1%86%BA%202020-11-18%20%E1%84%8B%E1%85%A9%E1%84%92%E1%85%AE%204.38.13.png?raw=true) | 게임 시작 화면
 게임 난이도 설정 | ![사진](https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7/blob/master/Project%20Img/%E1%84%89%E1%85%B3%E1%84%8F%E1%85%B3%E1%84%85%E1%85%B5%E1%86%AB%E1%84%89%E1%85%A3%E1%86%BA%202020-12-20%20%E1%84%8B%E1%85%A9%E1%84%92%E1%85%AE%203.27.20.png?raw=true) | 게임 난이도 화면
 게임 플레이화면 | ![사진](https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7/blob/master/Project%20Img/%E1%84%89%E1%85%B3%E1%84%8F%E1%85%B3%E1%84%85%E1%85%B5%E1%86%AB%E1%84%89%E1%85%A3%E1%86%BA%202020-12-20%20%E1%84%8B%E1%85%A9%E1%84%92%E1%85%AE%203.27.55.png?raw=true) | 게임 전방 화면
 게임 플레이화면 | ![사진](https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7/blob/master/Project%20Img/%E1%84%89%E1%85%B3%E1%84%8F%E1%85%B3%E1%84%85%E1%85%B5%E1%86%AB%E1%84%89%E1%85%A3%E1%86%BA%202020-12-20%20%E1%84%8B%E1%85%A9%E1%84%92%E1%85%AE%203.29.18.png?raw=true) | 게임 진행중 화면
 게임 오버 화면 | ![사진](https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7/blob/master/Project%20Img/%E1%84%89%E1%85%B3%E1%84%8F%E1%85%B3%E1%84%85%E1%85%B5%E1%86%AB%E1%84%89%E1%85%A3%E1%86%BA%202020-12-20%20%E1%84%8B%E1%85%A9%E1%84%92%E1%85%AE%203.29.29.png?raw=true) | 게임 오버 화면
 게임 랭킹 화면 | ![사진](https://github.com/CSID-DGU/2020-1-CECD3-UnpresentedFuture-7/blob/master/Project%20Img/%E1%84%89%E1%85%B3%E1%84%8F%E1%85%B3%E1%84%85%E1%85%B5%E1%86%AB%E1%84%89%E1%85%A3%E1%86%BA%202020-12-20%20%E1%84%8B%E1%85%A9%E1%84%92%E1%85%AE%203.29.42.png?raw=true) | 게임 난이도 화면

## 최종 발표 자료
- 동영상 링크 : https://drive.google.com/file/d/1aGJqpM4Y0oT14EXCDF5wRP0QutE3D471/view?usp=sharing
 
## 팀원
- 팀장) 윤기철
- 팀원) 나정민
- 팀원) 임성두
- 팀원) 이현재

## 문의
임성두 : [sungdoolim@naver.com](mailto:sungdoolim@naver.com)
