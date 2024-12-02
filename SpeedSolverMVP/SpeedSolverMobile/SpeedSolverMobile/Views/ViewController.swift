//
//  ViewController.swift
//  SpeedSolverMobile
//
//  Created by Алексей Суровцев on 26.10.2024.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

    @IBAction func didTapImRegistered(_ sender: Any) {
        Router.shared.pushUserAction(self, action: .authorize)
    }
    
    @IBAction func didTapImFirstTime(_ sender: Any) {
        
    }
}

