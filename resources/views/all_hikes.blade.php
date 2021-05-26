@extends('layouts.master')
@section('content')

<section class="parallax_window_in" data-parallax="scroll" data-image-src="img/2_day_toubkal_trek.jpg" data-natural-width="1400" data-natural-height="470">
    <div id="sub_content_in">
        <div id="animate_intro">
            <h1>Some of our favourite Hikes</h1>
            <p>Get around the High Atlas and beyond the best way</p>
        </div>
    </div>
</section>
<!-- End section -->
<!-- End SubHeader ============================================ -->

<section class="wrapper">
    <div class="divider_border_gray"></div>
    <div class="container">
        <div class="main_title_3">
            <br>
            <p>Not sure where to start? We’ve compiled some of our most popular hikes to help you brainstorm. Keep in mind that we have many more offerings than what you see here, so don’t be afraid to ask for something different.</p>
        </div>
        <div class="row">


@foreach ($uniqueUserIds as $uniqueUserId)
    
    <div class="col-md-4 col-sm-6 wow fadeIn animated" data-wow-delay="0.2s">
        <div class="img_wrapper">
            <div class="img_container">
                <a href="hikes_in_imlil.html">
                    <img src={{$uniqueUserId['img']}} width="800" height="533" class="img-responsive" alt="">
                    <div class="short_info">
                        <h3>{{$uniqueUserId['title']}}</h3>
                        <em>{{$uniqueUserId['title1']}}</em>
                        <p>
                            {{$uniqueUserId['body']}}                        </p>
                    </div>
                </a>
            </div>
        </div>
        <!-- End img_wrapper -->
    </div>
@endforeach
</div>
<!-- End row -->
</div>
<!-- End container -->
</section>
<br>
<section class="wrapperx">
    <div class="container">
        <div class="main_title_2">
            <h3 class="ls-l slide_typoxy">Want to completely customize your Hiking adventure?</h3>
            <p class="ls-l slide_typo_2x">Ask us about a personalized trek today!</p>
        </div>
        <div>
                <div class="bannerx" >
                     <p><a href="#0" class="btn_1_outlinex">CUSTOMISE YOUR TREK</a></p>
                </div>
                <!-- Edn row -->
        </div>
    </div>
    <!-- End container -->
</section>
@endsection