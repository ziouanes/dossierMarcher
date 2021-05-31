@extends('layouts.master')
@section('content')


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/sub_header_about.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>Health, Fitness and Safety</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>

        <div class="container">
            <div class="col-md-8 col-md-offset-2">
                <div class="row">
                    <div class="col-md-12">
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Health</font>
                        </h2>
                        <p>All the person who is physically fit and normal in health accept that they are only permitted to
                            walk on the Atlas for hiking. But if they have any sort of doubt about their health it is
                            necessary to take a doctor certificate to ensure that this type of walking is safe for you and
                            you are allowed to take part in the walk.</p>
                        <p>It is also recommended to inform the management in advance about any type of allergy or dietary
                            needs or medicines so that proper arrangements should be made and the proper meal is provided to
                            the participant.</p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Fitness</font>
                        </h2>
                        <p>Your safety is our priority; therefore, we ensure each step sensibly to make the tour comfortable
                            and enjoyable for the participant. However, walking is your choice and it is your own risk.</p>
                        <p>We provide the information on certain assumptions related to the walks, treks, or ascents. For
                            example, normal wellness and ability. The data has not really been provided particularly for
                            your own conditions. It is in this manner your obligation to consider such factors as your
                            physical wellness and any equipment that you should need to carry, especially where you set out
                            on an independent walk. We will not be responsible for any of accident, individual damage or
                            demise emerging from any of the strolls, aside from where passing or individual damage emerges
                            from our carelessness.</p>
                        <p>We maintain all authority to request that you sign a Disclaimer Form to affirm you know about,
                            and have acknowledged these terms and conditions. </p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Safety</font>
                        </h2>
                        <p>Some of our entire days guided strolls meant for a strong physical challenge, on the troublesome
                            landscape with sharp climbs or plummets. We claim all authority to practice our judgment in the
                            matter of whether an individual is reasonable to join a specific walk, and if fundamental, to
                            decay their interest in the case that it is thought to be for their own particular security and
                            that of different participants. The guide's choice and counselling need proper attention. No
                            responsibility will be taken in case of any mishap or accident because of not following the
                            directions.</p>
                        <p>A full suggested <a href="what_to_bring" target="_blank">kit list</a> is incorporated on our
                            site, and we claim all authority to cancel the participation of any walker who is, in the
                            conclusion of the guide, insufficiently prepared.</p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Children</font>
                        </h2>
                        <p>All the children must be taken under the supervision of a responsible adult that will accompany
                            them for ensuring the safety and wellbeing.</p>
                    </div>
                </div>
            </div>
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
