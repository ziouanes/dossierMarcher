<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Http;
use Storage;

class PostController extends Controller
{
    public function index(){
       
        $posts = file_get_contents(base_path('/storage/app/all_hikes.json'));
        $posts = json_decode($posts, true);
        
       $collection=collect($posts);
     
    
        return view('all_hikes',[

            'uniqueUserIds'=>$collection,
          
        ]);
    }
}
