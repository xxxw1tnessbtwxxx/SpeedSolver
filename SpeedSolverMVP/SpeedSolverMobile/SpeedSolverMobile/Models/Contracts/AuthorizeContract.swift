//
//  AuthorizeContract.swift
//  SpeedSolverMobile
//
//  Created by Алексей Суровцев on 27.10.2024.
//

import Foundation

class AuthorizeContract: Encodable {
    
    public let login: String
    public let password: String
    
    
    init(login: String, password: String) {
        self.login = login
        self.password = password
    }
}
