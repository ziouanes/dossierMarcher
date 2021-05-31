@extends('layouts.master')
@section('content')


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/2_day_toubkal_trek.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>What to bring</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <h3>What to bring with you when walking in High Atlas Mountains of Morocco:</h3>
                    <p>Sudden drops in temperatures are a normal thing in the weather of High Atlas. It is better to be
                        prepared for such an encounter as it is most likely to happen.</p>
                    <p>One important aspect to take care of is the footwear. The terrains are mostly rough and tough. Boots
                        will be advised with a tough sole and a firm grip for both the ground and your ankle. Testing your
                        new by walking around in them for a while is going to be good rather wear them new on your hike.
                        They might not fit your feet in a promising way.</p>
                    <p>The weather is not much certain and you might have to deal with skin issues even in cold months like
                        December, January and even February. So be prepared with a skin balm, full sleeves dress, long
                        trousers, and sunglasses or a hat.</p>
                    <p>And last but not the least, be confident to have a little supply of food and water because it is
                        essential to stay hydrated at all times and energy level needs to be up if you are also going up. If
                        you know what we mean. Happy Hiking.</p>
                    <p><a href="#0" class="btn_1">Suggested kit list for climbing Toubkal in winter</a></p>
                </div>
                <div class="col-sm-6">
                    <p class="advertise"><img src="{{ URL::asset('assets/img/trip-advisor.jpg') }}" alt="" class="img-responsive">
                    </p>
                </div>
            </div>
            <!-- End row -->
            <div class="row">
                <div class="col-sm-8">
                    <h2>We recommend that you bring with you:</h2>
                    <p>
                        - Good sturdy footwear – hard soles and good grip are the most essential<br>
                        - 25-30 litres day-pack<br>
                        - 3 to 4 season sleeping bag ( winter) or light Sleeping bag ( Summer)<br>
                        - Water bottle or camel back<br>
                        - Sun protection – hat, sun cream, sun glasses…<br>
                        - Light waterproofs<br>
                        - Walking pole(s)<br>
                        - Small personal medical kit – antiseptic wipes and cream, plasters, bandage, antihistamine for
                        allergic reactions…
                    </p>
                </div>
            </div>
            <!-- End row -->
            <div class="row">
                <div class="col-sm-8">
                    <h2>Other equipment you may find useful:</h2>
                    <p>
                        - Torch and batteries<br>
                        - Penknife (Pocket knife)<br>
                        - Whistle to attract attention<br>
                        - Compass<br>
                        - Binoculars<br>
                        - Camera<br>
                        - Loo (toilet) paper!<br>
                        - Ear plugs if staying in a refuge!<br>
                        - Soft, comfortable shoes and a change of clothes for the evening.
                    </p>
                </div>
            </div>
            <!-- End row -->
        </div>
        <!-- End container -->
    </section>
    <!-- End section -->
@endsection
@section('js')
    <!--Internal  Chart.bundle js -->
    <script src="{{ URL::asset('assets/plugins/jquery.selectbox-0.2.js') }}"></script>
    <script src="{{ URL::asset('assets/plugins/functions.js"') }}"></script>
    <script src="{{ URL::asset('assets/plugins/common_scripts_min.js') }}"></script>


    <script>
        $(".selectbox").selectbox();

    </script>
@endsection
