module App

open Elmish
open Elmish.React
open Feliz
open Feliz.PureReactCarousel
open Fable.Core.JsInterop

importSideEffects "pure-react-carousel/dist/react-carousel.es.css"

type State =
    { state: string }

type Msg = Init of string

let init() = { state = "yeah" }, Cmd.none

let update (msg: Msg) (state: State) =
    match msg with
    | Init string -> { state = "nope" }, Cmd.none

let carousel =
    Html.div
        [ prop.children
            [ PureReactCarousel.carouselProvider
                [ carouselProviderProps.naturalSlideHeight 125
                  carouselProviderProps.naturalSlideWidth 100
                  carouselProviderProps.totalSlides 3
                  carouselProviderProps.children
                      [ PureReactCarousel.slider
                          [ sliderProps.children
                              [ PureReactCarousel.slide
                                  [ slideProps.index 0
                                    slideProps.children [ Html.h3 [ prop.text "Slide 1" ] ] ]
                                PureReactCarousel.slide
                                    [ slideProps.index 0
                                      slideProps.children [ Html.h3 [ prop.text "Slide 1" ] ] ]
                                PureReactCarousel.slide
                                    [ slideProps.index 0
                                      slideProps.children [ Html.h3 [ prop.text "Slide 1" ] ] ] ] ] ] ] ] ]


let render (state: State) (dispatch: Msg -> unit) =
    carousel

#if DEBUG
open Elmish.HMR
#endif

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
