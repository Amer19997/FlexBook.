function forgetPassword() {
    $("#email").val($("#email").val().trim());
    if (!$("form")[0].checkValidity()) {
        $("form")[0].reportValidity();
        return;
    }
    var email = $("#email").val() ;
    
    $.ajax({
        url: "?handler=ForgetPassword",
        type: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        data: { "email": email},
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {
            

            if (result.success) {
                if (result.result.isBlocked == false) {
                    swal.fire({
                        title: result.result.message,
                        //text: result.result,
                        imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
                        showConfirmButton: false,
                    }).then(() => { window.location.replace("/Admin/Login"); });
                }
                else {
                    $(function () {

                    var remainingTime = parseFloat(result.result.remainingBlockMinutes);
                        console.log(remainingTime);

                        $('#panModal').modal('show');
                        var dealTimer = (function () {
                        var expires = new Date().getTime() + (remainingTime *1000);
                        var val = 100;
                        var mask = document.querySelector('#ticker');
                        var radius = mask.getAttribute('r');
                        var circum = Math.ceil(radius * 2 * Math.PI);
                        var interval = 1;
                        var dashOff;
                        var grad = document.getElementById('grad');
                        var cs1 = document.getElementById('stop1');
                        var cs2 = document.getElementById('stop2');
                        var txt = document.getElementById('remaining');
                        var tocolor = '#F88930';
                        var rotated = false;
                        var remaining;
                        var maxTime = remainingTime * 1000;
                        var ticked = [];

                        var colors = {
                            25: '#F88930'
                        }

                        var rotateGradient = function () {
                            grad.setAttribute('x1', 100);
                            grad.setAttribute('x2', 100);
                            grad.setAttribute('y1', 0);
                            grad.setAttribute('y2', 150);
                            rotated = true;
                        }

                        var changeColors = function (c) {
                            console.log('color change');
                            if (!rotated) rotateGradient();
                            cs2.style.stopColor = tocolor;
                            cs1.style.stopColor = c;
                            txt.style.color = tocolor;
                            tocolor = c;
                        };

                        mask.style.strokeDasharray = circum + ' ' + circum;

                        var progress = function () {
                            var tickby = remaining / maxTime * 1000;
                            var perc = (tickby * 100) << 0;
                            console.log(perc);
                            dashOff = (100 - tickby) * circum;
                            mask.style.strokeDashoffset = dashOff;
                            if (perc in colors && ticked.indexOf(perc) == -1) {
                                ticked.push(perc);
                                changeColors(colors[perc]);
                            }
                        };
                        var tick = function () {
                            remaining--;
                            progress()

                            txt.innerHTML = timeText(remaining);

                            if (remaining > 0) {
                                window.setTimeout(tick, 1000);
                            } else {
                                mask.style.stroke = 'none';
                            }
                            if (remaining == 0) {
                                // $( "#panModal" ).modal('hide');
                                document.getElementById('panBtn').classList.remove("disabled")
                            }
                        }

                        var timeText = function (ms) {
                            var min = (ms / 60) << 0,
                                sec = (ms) % 60;
                            return min + ':' + (sec < 10 ? '0' : '') + sec;

                        }

                        var timeLeft = function () {
                            var endTime = new Date().getTime() + maxTime;
                            remaining = Math.floor((endTime - new Date().getTime()) / 1000);
                            interval = remaining / circum;
                        };

                        var init = function () {
                            timeLeft();
                            tick();
                        }
                        init();
                    })();
                })

                }
                

            } else {
                swal.fire({
                    title: result.errors[0],
                    imageUrl: '/Cms_Lib/img/icons/warning-popup.svg',
                    showConfirmButton: false,
                });
            }


        }
    });

}