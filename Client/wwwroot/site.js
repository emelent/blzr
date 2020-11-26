(() => {
    console.log("Initialized");
    let resizeEventListener

    function attachWindowResizeListener(dotnetHelper) {
        resizeEventListener = event => {
            dotnetHelper.invokeMethodAsync(
                'OnWindowResize', 
                event.target.innerWidth,
                event.target.innerHeight
            )
        }

        window.addEventListener('resize', resizeEventListener)
        console.log("resize event attached")
    }

    function detachWindowResizeListener() {
        window.removeEventListener('resize', resizeEventListener)
        console.log("resize event detached")
    }

    window.Site = {
        attachWindowResizeListener,
        detachWindowResizeListener
    }
})()