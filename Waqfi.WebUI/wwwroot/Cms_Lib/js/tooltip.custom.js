const toolTip = document.querySelectorAll('.tollTip') 

function sum(offsetTop) {
    return `${offsetTop + 110}px`
}

toolTip.forEach(item => {
    item.children[0].style.top = sum(item.offsetTop)
    // item.children[0].style.left = `${item.offsetLeft - (item.offsetWidth)}px`
    item.children[0].offsetLeft < 500 ?item.children[0].style.left = `${item.offsetWidth}px` :item.children[0].style.left = `${item.offsetLeft - (item.offsetWidth)}px`

})
