//
//  AuthorizationController.swift
//  SpeedSolverMobile
//
//  Created by Алексей Суровцев on 27.10.2024.
//

import Foundation
import UIKit

class AuthorizationController: UIViewController {
    
    @IBOutlet weak var loginField: UITextField!
    @IBOutlet weak var passwordField: UITextField!
    override func viewDidLoad() {
        self.passwordField.isSecureTextEntry = true
    }
    
    
    @IBAction func didTapAuthPressed(_ sender: Any) {
        
        if ((loginField.text == nil || ((loginField.text?.isEmpty) != nil)) == true) {
            
        }
        
        APIService.shared.Authorize(credentials: AuthorizeContract(login: loginField.text!, password: passwordField.text!))
    }
    
}
