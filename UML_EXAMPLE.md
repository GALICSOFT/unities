# UML

## PlantUML
#### link
  * guide: https://plantuml.com/ko/
  * web server: https://www.plantuml.com/plantuml/uml/SoWkIImgAStDuNBAJrBGjLDmpCbCJbMmKiX8pSd9vt98pKi1IW80
  * style: https://github.com/plantuml/plantuml/tree/master/themes

#### example
* font list
```plantuml
listfonts
```

* arrow
```plantuml
a -> b : ""-> ""
a ->> b : ""->> ""
a -\ b : ""-\ ""
a -\\ b : ""-\\\\""
a -/ b : ""-/ ""
a -// b : ""-// ""
a ->x b : ""->x ""
a x-> b : ""x-> ""
a o-> b : ""o-> ""
a ->o b : ""->o ""
a o->o b : ""o->o ""
a <-> b : ""<-> ""
a o<->o b : ""o<->o""
a x<->x b : ""x<->x""
a ->>o b : ""->>o ""
a -\o b : ""-\o ""
a -\\o b : ""-\\\\o""
a -/o b : ""-/o ""
a -//o b : ""-//o ""
a x->o b : ""x->o ""
```

* style
```plantuml
skinparam useBetaStyle true
' style enclosure declaration
<style>
    ' scope to sequenceDiagram elements
    sequenceDiagram {

      ' scope to actor element types
      actor {
        FontColor Blue
      }

     ' define a new style, using CSS class syntax
     .myStyle {
        FontColor Red
     }

}
</style>
' printed in blue
actor Bob
' this will now be printed in Red
actor Sally <<myStyle>>
```

* sequence
```plantuml
skinparam defaultFontName Segoe UI
skinparam BackgroundColor EDEDED
skinparam shadowing false
skinparam RoundCorner 20
skinparam ArrowColor 454645
skinparam FontColor 454645
skinparam SequenceLifeLineBorderColor 454645
skinparam SequenceGroupHeaderFontColor 454645
skinparam SequenceGroupFontColor 454645
skinparam SequenceGroupBorderColor 454645
skinparam SequenceGroupBorderThickness 1
skinparam sequenceDivider {
    BorderColor 454645
    BorderThickness 1
    FontColor 454645
}
skinparam participant {
    BackgroundColor ffd060
    BorderColor 454645
    FontColor Black
    BorderThickness 1.5
}
skinparam database {
    BackgroundColor 98DDDE
    BorderColor 454645
    FontColor 454645
}
skinparam entity {
    BackgroundColor FFDA29
    BorderColor 454645
    FontColor 454645
}
skinparam note {
    BackgroundColor LightYellow
    BorderColor 454645
    FontColor 454645
    BorderThickness 1
}
skinparam actor {
    BackgroundColor 454645
    BorderColor 454645
    FontColor 454645
}
skinparam boundary {
    BackgroundColor FFDA29
    BorderColor 454645
    FontColor 454645
}
skinparam control {
    BackgroundColor FFDA29
    BorderColor 454645
    FontColor 454645
}
skinparam collections {
    BackgroundColor FF6F61
    BorderColor 454645
    FontColor 454645
    BorderThickness 1.5
}
skinparam queue {
    BackgroundColor FF6F61
    BorderColor 454645
    FontColor FFF
    BorderThickness 1.5
}
participant App
note right of App
  memo 1
end note
App -> AppManager : action0
        AppManager -> OtherSDK: action0(param0)
        OtherSDK -> OtherSDK: action1.action0
alt action1 exist
    OtherSDK -> SecondModule: action1 params
else not exist
    OtherSDK -> SecondModule: action2 : action3 : params
end    
SecondModule -->> App : onCallback
```

![class-diagram](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/GALICSOFT/unities/main/sequence-daiagram.puml)


## Mermaid
#### link
  * guide: https://mermaid-js.github.io/mermaid
  * web: https://mermaid-js.github.io/mermaid-live-editor/edit#pako:eNptkUFrxCAQhf-KnVMX0qYUevFW2F563UOheDE6jbJRUzOyLCH_vbomhMK-Q2TmfeYN4wwqaAQOE_4m9AqPVvZROuFZlkwUfHIdxlpHVMRi3z2-vr00bPsc2KoKFY0yklV2lJ7Y-2AV3rc-g_G7M1h_nirO2SzgKCfTBRm1AM4EGKJx4m2rt_azCp7CFPLpWnlLgSaDX_Zs_1-55M49etnDb7FPhzIRZydEdg2JDZIwPlQIvd7pImjAYXTS6ry-uXgCOqnOfQzJrzNfjKUyVXXJoMNqDLY3JED4Jf8mjToHfWhLIQKnmLCBsvrT1autrsz6OlszL_E7hFz-yGHC5Q-RfZIW
  
  
 #### example
* style

```mermaid
flowchart LR
    App(Start)-->AppSDK(Stop)
    style App fill:#f9f,stroke:#333,stroke-width:4px
    style AppSDK fill:#bbf,stroke:#f66,stroke-width:2px,color:#fff,stroke-dasharray: 5 5
```

* sequence loop
```mermaid
sequenceDiagram
rect rgb(250, 250, 250)
    App->>AppSDK: Hello John, how are you?
    loop Healthcheck
        AppSDK->>AppSDK: Fight against hypochondria
    end
    Note right of AppSDK: Rational thoughts <br/>prevail!
    AppSDK-->>App: Great!
    AppSDK->>AppSDK: How about you?
    AppSDK-->>App: Jolly good!
end
```	

* sequence
```mermaid
sequenceDiagram
    autonumber
    actor App
    participant AppSDK
    participant Server
    participant Google
    participant Database
    participant Cloud_Server
  App->>AppSDK: 파일 업로드 버튼 클릭
    AppSDK->>App: 구글 로그인 popup 제공
    App->>Google: 구글 로그인
    Google->>AppSDK: ID 토큰 응답
    AppSDK->>Server: ID 토큰과 업로드 파일 전달
    Server->>Google: ID 토큰 검증 요청
    Google->>Server: ID 토큰 검증 결과 응답
    alt is 검증 확인
        Server->>Database: 정보 저장
        Database->>Server: 정상 insert 확인 응답
        Server--)Cloud_Server: 파일 업로드
        Server->>AppSDK: 업로드 성공 응답
        activate AppSDK
        AppSDK->>AppSDK: 성공 UI 랜더링
        deactivate AppSDK
        AppSDK->>App: 성공 확인
    else is 검증 실패
        Server->>AppSDK: 업로드 실패 응답
        activate AppSDK
        AppSDK->>AppSDK: 실패 UI 랜더링
        deactivate AppSDK
        AppSDK->>App: 실패 확인
    end
```
