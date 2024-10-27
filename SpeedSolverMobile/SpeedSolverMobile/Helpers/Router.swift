//
//  Router.swift
//  SpeedSolverMobile
//
//  Created by Алексей Суровцев on 27.10.2024.
//

import Foundation
import UIKit



final class Router {
    
    static let shared = Router()
    
    private init() { }
    
    public func pushUserAction(_ from: UIViewController, action: UserAction) {
        
        if (action == .authorize) {
            let vc = UIStoryboard(name: "AuthorizationView", bundle: nil).instantiateViewController(withIdentifier: "AuthorizeStoryboard") as! AuthorizationController
            
            from.navigationController?.pushViewController(vc, animated: true)
        }
        
    }
    
}
