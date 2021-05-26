<!-- COMMON SCRIPTS -->
<script src="{{URL::asset('assets/plugins/jquery-2.2.4.min.js')}}"></script>
<script src="{{URL::asset('assets/plugins/common_scripts_min.js')}}"></script>
<script src="{{URL::asset('assets/plugins/validate.js')}}"></script>
<script src="{{URL::asset('assets/plugins/jquery.tweet.min.js')}}"></script>
<script src="{{URL::asset('assets/plugins/functions.js"')}}"></script>

	 <!-- SPECIFIC SCRIPTS -->
     <script src="{{URL::asset('assets/layerslider/js/greensock.js')}}"></script>
     <script src="{{URL::asset('assets/layerslider/js/layerslider.transitions.js')}}"></script>
     <script src="{{URL::asset('assets/layerslider/js/layerslider.kreaturamedia.jquery.js')}}"></script>
    
   



<script type="text/javascript">
    'use strict';
    $('#layerslider').layerSlider({
        autoStart: true,
        navButtons: false,
        navStartStop: false,
        showCircleTimer: false,
        responsive: true,
        responsiveUnder: 1280,
        layersContainer: 1200,
        skinsPath: 'layerslider/skins/'
            // Please make sure that you didn't forget to add a comma to the line endings
            // except the last line!
    });
</script>

 <script src="{{URL::asset('assets/plugins/jquery.cookiebar.js')}}"></script>
 <script src="{{URL::asset('assets/plugins/lazy_load')}}"></script>
<script>
    'use strict';
    $.cookieBar({
        fixed: true
    });
</script>
<script>
    $(document).ready(function(){
        $("img").lazy();
    })
</script>
@yield('js')
